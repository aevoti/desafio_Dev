export class Aluno {
    constructor(alunoId?: number, nome?: string, email?: string) {
        this.alunoId = alunoId;
        this.nome = nome;
        this.email = email;
    }

    alunoId: number;
    nome: string;
    email: string;
}