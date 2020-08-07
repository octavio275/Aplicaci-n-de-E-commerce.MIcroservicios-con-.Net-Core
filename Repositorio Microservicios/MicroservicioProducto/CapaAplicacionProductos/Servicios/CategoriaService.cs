using CapaDominioProductos.Comandos;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CapaAplicacionProductos.Servicios
{
    public interface ICategoriaService
    {
        CategoriaDto createCategoria(string descripcion);
       Categoria actualizarCategoria(Categoria categoria);
    }
    public class CategoriaService :ICategoriaService
    {
        private readonly IGenericsRepository repository;

        public CategoriaService(IGenericsRepository repository)
        {
            this.repository = repository;
        }

        public Categoria actualizarCategoria(Categoria categoria)
        {
           
            return repository.Update(categoria);
        }

        public CategoriaDto createCategoria(string descripcion)
        {
            var entity = new Categoria()
            {
                Descripcion = descripcion
                
            };
            repository.Agregar<Categoria>(entity);
            return new CategoriaDto {Descripcion = entity.Descripcion };
        }
        
    }
}
