using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Services
{
    public class FormServices : IFormServices
    {
        private readonly IServiceScope _scope;
        private readonly GridFormContext _databaseContext;
        public FormServices(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _databaseContext = _scope.ServiceProvider.GetRequiredService<GridFormContext>();
        }

        public async Task<List<Form>> GetForms()
        {
            if (_databaseContext != null)
            {
                return await _databaseContext.Forms.ToListAsync();
            }

            return null;
        }

        public async Task<Form> GetForm(int formId)
        {
            if (_databaseContext != null)
            {
                var form = await _databaseContext.Forms.FirstOrDefaultAsync(f => f.FormId == formId);
                return form;
            }
            return null;
        }

        public async Task<List<FormData>> GetFormData(int formId)
        {
            if (_databaseContext != null)
            {
                return await (_databaseContext.FormData.Where(x => x.FormId == formId)).ToListAsync();
            }

            return null;
        }

        public async Task<int> AddForm(Form form)
        {
            if (_databaseContext != null)
            {
                await _databaseContext.Forms.AddAsync(form);
                await _databaseContext.SaveChangesAsync();

                return form.FormId;
            }

            return 0;
        }

        public async Task<int> AddFormData(FormData formData)
        {
            if (_databaseContext != null)
            {
               
                var formId = formData.FormId;
                if (formId != 0)
                {
                    await _databaseContext.FormData.AddAsync(formData);
                    await _databaseContext.SaveChangesAsync();
                }
               
                return formData.FormDataId;
            }

            return 0;
        }

          
        public async Task<int> DeleteForm(int formId)
        {
            int result = 0;

            if (_databaseContext != null)
            {

                var form = await _databaseContext.Forms.FirstOrDefaultAsync(f => (f.FormId == formId));

                if (form != null)
                {

                  var dataList = await GetFormData(formId);
                    foreach (FormData data in dataList)
                    {
                        _databaseContext.FormData.Remove(data);
                    }
                    _databaseContext.Forms.Remove(form);

                    result = await _databaseContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<int> DeleteFormData(int formDataId)
        {
            int result = 0;

            if (_databaseContext != null)
            {

                var formData = await _databaseContext.FormData.FirstOrDefaultAsync(f => (f.FormDataId == formDataId));

                if (formData != null)
                {

                    _databaseContext.FormData.Remove(formData);

                    result = await _databaseContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<int> UpdateFormData(FormData formData)
        {
            int result = 0;
            if (_databaseContext != null)
            {
                var updatedFormData = await _databaseContext.FormData.FirstOrDefaultAsync(fd => (fd.FormDataId == formData.FormDataId));
                if (updatedFormData != null)
                {
                    updatedFormData.FormItem = formData.FormItem;
                    _databaseContext.FormData.Update(updatedFormData);
                    result = await _databaseContext.SaveChangesAsync();
                }

            }
            return result;
        }
    }
}
