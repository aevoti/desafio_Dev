export class Aluno {
  alunoId: number;
  nome: string;
  email: string;

  constructor(aluno?: Aluno) {
    if(aluno) {
      if(aluno.alunoId) { this.alunoId = aluno.alunoId }
      if(aluno.nome) { this.nome = aluno.nome }
      if(aluno.email) { this.email = aluno.email }
    }
  }
}
