using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace CrudAssignment.Service
{
    public interface ICategoryService : IService<Category>
    {
    }

    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IRepositoryAsync<Category> _categoryRepository;

        public CategoryService(IRepositoryAsync<Category> categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
