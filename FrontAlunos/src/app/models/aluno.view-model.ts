export class AlunoViewModel {

  public constructor(init?: Partial<AlunoViewModel>){
    Object.assign(this, init);
  }

  id: number;
  nome: string;
  email: string;
}
