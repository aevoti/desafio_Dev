import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';

import { ALUNO_SERVICE, HttpService } from "../../shared/services";

import { Aluno, Pagination } from "../../shared/models";
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../components/delete-dialog/delete-dialog.component';
import { Observable } from 'rxjs';
// import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
})
export class AlunoComponent implements OnInit {

  /* MatTable */
  public tableColumns: string[] = ['alunoId', 'nome', 'email', 'acoes'];
  public data: MatTableDataSource<Aluno>;

  // sort
  @ViewChild(MatSort, {read: MatSort}) public sort: MatSort;
  public sortAttr = '';
  public sortDirection = '';

  // pagination
  @ViewChild(MatPaginator, { read: MatPaginator }) public paginator: MatPaginator
  public currentPage = 0;
  public pageSize = 10;
  public paginationData: Pagination;
  /* MatTable */

  /* Serach */
  public searchForm = this.fb.group({
    name: [''],
    id: [undefined]
  });

  /* Submit */
  public alunoForm = this.fb.group({
    alunoId: [undefined],
    nome: [undefined, [Validators.required]],
    email: [undefined, [Validators.email]]
  });

  public submitted = false;
  /* Submit */

  constructor(
    public matDialog: MatDialog,
    @Inject(ALUNO_SERVICE) private alunoService: HttpService<Aluno>,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadAlunos(false, true);
  }

  public handlePage(event) {
    this.currentPage = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadAlunos();
  }

  public handleSort(event: Sort) {
    this.sortAttr = event.active;
    this.sortDirection = event.direction;
    this.loadAlunos();
  }

  public handleKey(event: KeyboardEvent) {
    if (event.keyCode === 13) {
      this.search();
    }
  }

  public loadAlunos(fromFilter = false, setTable = false) {
    this.alunoService.getAll([
      { key: 'nome', value: this.searchForm.controls.name.value},
      { key: 'pageNumber', value: fromFilter ? '0' : this.currentPage.toString() },
      { key: 'pageSize', value: this.pageSize.toString() },
      { key: 'orderBy', value: this.sortAttr + ' ' + this.sortDirection}
    ])
      .subscribe(
        alunosResponse => {
          this.data = new MatTableDataSource(alunosResponse.body);
          this.paginationData = JSON.parse(alunosResponse.headers.get('X-Pagination'));
          this.data.sort = this.sort;
          if (setTable) { this.data.paginator = this.paginator; }
        }
      )
  }

  public loadAluno(id: number) {
    this.alunoService.get(id).subscribe(
      aluno => {
        this.data = new MatTableDataSource([aluno]);
        this.data.sort = this.sort;
      },
      err => {

      }
    )
  }

  public search() {
    const id = this.searchForm.controls.id.value;
    const name = this.searchForm.controls.name.value;

    console.log(id);
    console.log(name);

    if ( id != null && name == '' ) {
      this.loadAluno(id);
    } else {
      this.loadAlunos(true)
    }
  }

  public openDeleteDialog(aluno: Aluno) {
    const dialog = this.matDialog.open(DeleteDialogComponent);

    dialog.afterClosed()
      .subscribe(result => {
        if (result) { this.deleteAluno(aluno.alunoId) }
      })
  }

  public editAluno(aluno: Aluno) {
    this.alunoForm.patchValue(aluno);
  }

  private deleteAluno(id: number) {
    this.alunoService.delete(id)
      .subscribe(
        suc => {
          this.loadAlunos();
        },
        err => {
          console.log(err)
        }
      )
  }

  public submit() {
    this.submitted = true;

    if (this.alunoForm.valid) {

      const aluno = new Aluno(this.alunoForm.value);
      const method = this.getHttpMethod(aluno);

      console.log(aluno);
      method.subscribe(
        suc => {
          this.loadAlunos();
        },
        err => {
          console.log(err);
        },
        () => {
          this.alunoForm.reset();
        }
      )
    }
  }

  private getHttpMethod(aluno: Aluno): Observable<Aluno> {
    if (aluno.alunoId) {
      return this.alunoService.put(aluno.alunoId, aluno )
    } else {
      return this.alunoService.post(aluno);
    }
  }

  get form() { return this.alunoForm.controls; }

}
