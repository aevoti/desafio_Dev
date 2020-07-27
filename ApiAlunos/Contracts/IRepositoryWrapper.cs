namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAlunoRepository Aluno { get; }
        void Save();
    }
}
