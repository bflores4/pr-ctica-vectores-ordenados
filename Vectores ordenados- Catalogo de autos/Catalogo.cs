using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectores_ordenados__Catalogo_de_autos
{
    class Catalogo
    {
        private Auto[] catalogoDeAutos;
        private int _tamañoCatalogo;
        private int _elementosRegistrados = 0;

        public int elementosRegistrados
        { get { return _elementosRegistrados; } }

        public Catalogo(int tamañoCatalogo)
        {
            _tamañoCatalogo = tamañoCatalogo;
            catalogoDeAutos = new Auto[tamañoCatalogo];
        }

        public void agregar(Auto autoParaAgregar)
        {
                catalogoDeAutos[_elementosRegistrados] = autoParaAgregar;
                _elementosRegistrados++;
        }

        public Auto buscarAuto(string placa)
        {
            Auto autoBuscado = null;
            bool encontrado = false;

            for(int i=0; i<_elementosRegistrados && encontrado == false; i++)
            {
                if (placa == catalogoDeAutos[i].placa)
                {
                    autoBuscado = catalogoDeAutos[i];
                    encontrado = true;
                    return autoBuscado;
                }
            }
            return autoBuscado;
        }

        private int buscarPosicion(string placa)
        {
            int posicionBuscada = -1;
            bool encontrado = false;

            for (int i = 0; i < _elementosRegistrados && encontrado == false; i++)
            {

                if (placa == catalogoDeAutos[i].placa)
                {
                    posicionBuscada = i;
                    encontrado = true;
                    return posicionBuscada;
                }
            }
            return posicionBuscada;
        }

        public void eliminar(string placa)
        {
            int posicion= buscarPosicion(placa);

            if ( posicion!= -1)
            {
                for (int j = posicion; j < _elementosRegistrados - 1; j++)
                {
                    catalogoDeAutos[j] = catalogoDeAutos[j +1];
                }
                _elementosRegistrados--;
            }
        }

        public string listar() 
        {
            string listaAutos = "";
            for (int i = 0; i < _elementosRegistrados; i++)
            {
                listaAutos += catalogoDeAutos[i].ToString();
            }
            return listaAutos;
        }

        public void ordenar(Auto nuevoAuto)
        {
            for (int contador = 0; contador <= _elementosRegistrados; contador++)
            {
                if (catalogoDeAutos[contador] != null)
                {
                    if (nuevoAuto.placa.CompareTo(catalogoDeAutos[contador].placa)<0)
                    {
                        for (int i = _elementosRegistrados; i > contador ; i--)
                        {
                            catalogoDeAutos[i] = catalogoDeAutos[i - 1];
                        }
                        catalogoDeAutos[contador] = nuevoAuto;
                        contador = _elementosRegistrados;
                    }
                }
                else
                {
                    catalogoDeAutos[contador] = nuevoAuto;
                }
            }
            _elementosRegistrados++;
        }
    }

}
