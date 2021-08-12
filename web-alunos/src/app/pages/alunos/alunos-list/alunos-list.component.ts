import { Component, OnInit } from '@angular/core';
import { AlunosModel } from 'src/app/models/alunos.model';
import { AlunosService } from 'src/app/services/alunos.service';
import { ActionType } from 'src/app/shared/models/action-type.enum';
import { Action } from 'src/app/shared/models/action.model';
import { Column } from 'src/app/shared/models/column.model';

@Component({
  selector: 'app-alunos-list',
  templateUrl: './alunos-list.component.html',
  styleUrls: ['./alunos-list.component.scss']
})
export class AlunosListComponent implements OnInit {

  constructor(
    public alunosService: AlunosService
  ) { }

  alunos: AlunosModel[] = [];
  alunoId: string;
  alunosClasse: any = AlunosModel;
  alunosModel: AlunosModel = new AlunosModel();
  columns: Column<AlunosModel>[];
  actions: Action<AlunosModel>[];
  isActiveDeletar: boolean;
  camposParaPesquisaFiltro: string[] = [];
  tituloAluno: string;
  idNameProperty: string = 'alunoId';

  ngOnInit(): void {
    this.buscarAlunos();
    this.initializeDatatable();
    this.camposParaPesquisaFiltro = ['nome'];
    this.tituloAluno = 'Alunos';
  }

  initializeDatatable(): void {

    // Inicialização das colunas
    this.columns = [
      {
        field: 'nome',
        header: 'Nome do aluno',
        width: '40%',
        value: null
      },
      {
        field: 'email',
        header: 'Email',
        width: '40%',
        value: null
      },
    ];

    this.actions = [
      {
        title: 'Alterar',
        icon: 'pi-pencil',
        iconType: 'pi',
        iconColor: 'success',
        actionType: ActionType.change
      },
      {
        title: 'Deletar',
        icon: 'pi-trash',
        iconType: 'pi',
        iconColor: 'warning',
        actionType: ActionType.delete
      },
    ];
  }

  buscarAlunos() {
    this.alunosService.getAll().subscribe(resposta => {
      this.alunos = resposta;
    });
  }

  isDesactiveDelete(event) {
    this.isActiveDeletar = event;
  }

  limparModelAluno(event) {
    this.alunosModel = event;
  }

  limparIdAluno(event) {
    this.alunoId = event;
  }

  reloadAlunos(event) {
    if (event === true) {
      this.buscarAlunos();
    }
  }
}
