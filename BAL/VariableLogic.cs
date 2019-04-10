using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class VariableLogic : IVariableLogic
    {
        public IEnumerable<VariableDto> GetAll()
        {
            var repository = new DataRepository();
            var allVariables = repository.GetAll();
            //var a = allVariables.First();
            //var mapped = Mapper.Map<VariableDto>(a);

            return Mapper.Map<IEnumerable<Variable>, IEnumerable<VariableDto>>(allVariables);
        }
        public void Update(VariableDto variableDto)
        {
            var repository = new DataRepository();
            var variable = Mapper.Map<Variable>(variableDto);
            repository.Update(variableDto.VariableId, variable);
        }
        public void Delete(int id)
        {
            var repository = new DataRepository();
            repository.Delete(id);
        }
        public void Add(VariableDto variableDto)
        {
            var repository = new DataRepository();
            var variable = Mapper.Map<Variable>(variableDto);
            repository.Add(variable);
        }
    }
    public class VariableDto
    {
        [DisplayName("ID")]
        public int VariableId { get; set; } // VariableId (Primary key)
        public string Name { get; set; } // Name (Primary key) (length: 50)
        [DisplayName("Start Date")]
        public System.DateTime? StartDate { get; set; } // StartDate
        public string Value { get; set; } // Value (length: 50)
        public string Type { get; set; } // Type (length: 50)
        //public string Action { get; set; }
    }
}
