﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace ClasesAbstractas
{
    /// <summary>
    /// . Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
    /// . Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. Caso contrario, 
    ///   se lanzará la excepción DniInvalidoException.
    /// . Sólo se realizarán las validaciones dentro de las propiedades.
    /// . Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
    /// . ToString retornará los datos de la Persona.
    /// </summary>
    public abstract class Persona
    {
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this._apellido = value;
                }
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = ValidarDni(Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this._nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(Nacionalidad, value);
            }
        }

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            cadena.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return cadena.ToString();
        }

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. 
        /// Caso contrario, se lanzará la excepción DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (((nacionalidad.Equals(ENacionalidad.Argentino)) && (dato < 0 || dato > 90000000)))
            {
                throw new DniInvalidoException();
            }
            if (((nacionalidad.Equals(ENacionalidad.Extranjero)) && (dato < 90000000)))
            {
                throw new NacionalidadInvalidaException();
            }

            return dato;
        }

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999. Caso contrario, se lanzará la excepción DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string aux = null;

            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
            {
                aux = dato;
            }

            return aux;
        }

        /// <summary>
        /// Enum que contiene las posibles nacionalidades de las personas
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
