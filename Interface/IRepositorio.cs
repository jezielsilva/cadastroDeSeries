﻿using System.Collections.Generic;

namespace cadastroDeSeries
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}