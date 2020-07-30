using Alunos.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alunos.Application.UseCases
{
    public class GetAlunos : IRequest<IEnumerable<AlunoViewModel>>
    {
        public string Filter { get; set; }
        public SortType SortType { get; set; }
    }

    public enum SortType
    {
        ORDER_BY_NOME_ASC,
        ORDER_BY_NOME_DEC,
        ORDER_BY_ID_ASC,
        ORDER_BY_ID_DEC
    }

    public static class SortTypeUtil
    {
        public static SortType FromString(string sortType)
        {
            switch(sortType)
            {
                case "ID_ASC":
                    return SortType.ORDER_BY_ID_ASC;
                case "ID_DEC":
                    return SortType.ORDER_BY_ID_DEC;
                case "NOME_ASC":
                    return SortType.ORDER_BY_NOME_ASC;
                case "NOME_DEC":
                    return SortType.ORDER_BY_NOME_DEC;
                default:
                    return SortType.ORDER_BY_ID_ASC;
            }
        }
    }
}
