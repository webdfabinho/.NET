using System;
using System.Collections.Generic;
using fabio.series.interfaces;

namespace fabio.series
{
    public class SerieRepositorio : IRepositorio<serie>
    {
        private List<serie> listaserie = new List<serie>();
        public void Atualiza(int id, serie objeto)
        {
            listaserie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaserie[id].Excluir();
        }

        public void Insere(serie objeto)
        {
            listaserie.Add(objeto);
        }

        public List<serie> Lista()
        {
            return listaserie;
        }

        public int ProximoId()
        {
            return listaserie.Count;
        }

        public serie RetornaPorId(int id)
        {
            return listaserie[id];
        }
    }
}