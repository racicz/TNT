using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Shared.Enum;

namespace TNT.Shared.Messages
{
    public class RepositoryResponse<TEntity>
    {
        public TEntity Entity { get; set; }

        public RepositoryActionStatus Status { get; internal set; }

        public string Error { get { return Helper.ResponseError(Errors); } }

        public dynamic Errors { get; set; }
        public string Stamp { get; set; }

        public RepositoryResponse<TEntity> SetStatus(RepositoryActionStatus status)
        {
            Status = status;
            return this;
        }
        public static RepositoryResponse<TEntity> Success(TEntity data, RepositoryActionStatus status = RepositoryActionStatus.Ok) => new RepositoryResponse<TEntity> { Status = status, Entity = data };
        public static RepositoryResponse<TEntity> Failure(string error = "") => new RepositoryResponse<TEntity> { Status = RepositoryActionStatus.Fail, Errors = new[] { error } };
        public static RepositoryResponse<TEntity> Failure(string error = "", RepositoryActionStatus status = RepositoryActionStatus.Fail) => new RepositoryResponse<TEntity> { Status = status, Errors = new[] { error } };
        public static RepositoryResponse<TEntity> Failure(string[] errors) => new RepositoryResponse<TEntity> { Status = RepositoryActionStatus.Fail, Errors = errors };
        public static RepositoryResponse<TEntity> Failure() => new RepositoryResponse<TEntity> { Status = RepositoryActionStatus.Forbidden };
        public static RepositoryResponse<TEntity> Failure(IEnumerable<IdentityError> errors) => new RepositoryResponse<TEntity> { Status = RepositoryActionStatus.Fail, Errors = errors };
    }

    internal class Helper
    {
        public static string ResponseError(string[] errors)
        {
            string results = string.Empty;

            if (errors != null && errors.Length > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string error in errors)
                {
                    if (!string.IsNullOrEmpty(error))
                    {
                        if (sb.Length > 0)
                            sb.Append(" ");

                        sb.Append(error);
                    }
                }

                results = sb.ToString();
            }

            return results;
        }

        public static string ResponseError(IEnumerable<IdentityError> errors)
        {
            string results = string.Empty;

            if (errors != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var error in errors)
                {
                    if (error != null)
                    {
                        if (sb.Length > 0)
                            sb.Append(" ");

                        sb.Append(error.Description);
                    }
                }

                results = sb.ToString();
            }

            return results;
        }
    }

    
}
