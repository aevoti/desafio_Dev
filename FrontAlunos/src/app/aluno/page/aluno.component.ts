import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { ALUNO_SERVICE, HttpService } from "../../shared/services";

import { Aluno, Pagination } from "../../shared/models";

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
})
export class AlunoComponent implements OnInit {

  /* MatTable */
  public columns: string[] = ['alunoId', 'nome', 'email', 'acoes'];
  public data: MatTableDataSource<Aluno>;

  // sort
  @ViewChild(MatSort, {read: MatSort}) public sort: MatSort;

  // pagination
  @ViewChild(MatPaginator, { read: MatPaginator }) public paginator: MatPaginator
  public currentPage = 0;
  public pageSize = 20;
  public paginationData: Pagination;
  /* MatTable */

  constructor(
    @Inject(ALUNO_SERVICE) private alunoService: HttpService<Aluno>
  ) {}

  ngOnInit(): void {
    this.loadAlunos(false, true);
  }

  public handlePage(event) {
    this.currentPage = event.pageIndex;
    this.pageSize = event.pageSize;
    this.loadAlunos();
  }

  public loadAlunos(fromFilter = false, setTable = false) {
    this.alunoService.getAll([
      { key: 'pageNumber', value: fromFilter ? '0' : this.currentPage.toString() },
      { key: 'pageSize', value: this.pageSize.toString() }
    ])
      .subscribe(
        alunosResponse => {
          console.log(alunosResponse);
          this.paginationData = JSON.parse(alunosResponse.headers.get('X-Pagination'));
          this.data = new MatTableDataSource(alunosResponse.body);
          this.buildTable();
          if (setTable) { this.data.paginator = this.paginator; }
        }
      )
  }

  public buildTable(): void {
    this.data.sort = this.sort;
  }

  public openDeleteModal(a: any) {

  }

}
