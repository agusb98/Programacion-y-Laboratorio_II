﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Deposito
    {
        #region Atributos

        public List<Producto> productos;

        #endregion

        #region Constructores

        /// <summary>
        /// El contructor por defecto instancia 3 lugares a la lista de Productos
        /// </summary>
        public Deposito() : this(3) { }

        /// <summary>
        /// Instancia cantidad de lugares dentro de la lista de Productos
        /// </summary>
        /// <param name="cantidad"></param>
        public Deposito(int cantidad) { productos = new List<Producto>(cantidad); }

        #endregion

        #region Sobrecarga de Operadores

        public static List<Producto> operator + (Deposito d1, Deposito d2)
        {
            List<Producto> suma = d1.productos;

            foreach (Producto prod2 in d2.productos)
            {
                if (suma.Contains(prod2))
                {
                    foreach (Producto prod1 in suma)
                    {
                        if (prod1.nombre == prod2.nombre)
                        {
                            prod1.stock += prod2.stock;
                        }
                    }
                }
                else
                {
                    suma.Add(prod2);
                }
            }
            return suma;
        }

        public static void OrdenarAscendente(Deposito d1)
        {
            d1.productos.Sort((p1, p2) => p1.stock.CompareTo(p2.stock));
        }

        public static void OrdenarAlfabetico(Deposito d1)
        {
            d1.productos.Sort((p1, p2) => string.Compare(p1.nombre, p2.nombre));
        }

        #endregion
    }
}
