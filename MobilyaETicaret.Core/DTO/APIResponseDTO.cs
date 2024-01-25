using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class APIResponseDTO<TEntity>
    {
        public TEntity Data { get; set; }

        [JsonIgnore]
        public int StatuCode { get; set; }
        public List<string> Errors { get; set; }

        public static APIResponseDTO<TEntity> Success(int statuCode, TEntity data)
        {
            return new APIResponseDTO<TEntity> { Data = data, StatuCode = statuCode };
        }

        public static APIResponseDTO<TEntity> Success(int statuCode)
        {
            return new APIResponseDTO<TEntity> { StatuCode = statuCode };
        }

        public static APIResponseDTO<TEntity> Fail(int statuCode, List<string> errors)
        {
            return new APIResponseDTO<TEntity> { StatuCode = statuCode, Errors = errors };
        }

        public static APIResponseDTO<TEntity> Fail(int statuCode, string error)
        {
            return new APIResponseDTO<TEntity> { StatuCode = statuCode, Errors = new List<string> { error } };
        }
    }
}
