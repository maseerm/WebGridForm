using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IFormServices
    {
        Task<List<Form>> GetForms();
        Task<List<FormData>> GetFormData(int formId);
        Task<Form> GetForm(int formId);

        Task<int> AddForm(Form form);
        Task<int> AddFormData(FormData formData);

        Task<int> DeleteForm(int formId);
        Task<int> DeleteFormData(int formDataId);
        Task<int> UpdateFormData(FormData formData);
    }
}
