using System.Data.Entity.Validation;
using System.Net.Sockets;
using System.Text;


namespace TNT.Shared.Extentions
{
	public static class ExceptionExtensions
	{
		public static string FormatException(this Exception ex)
		{
			if (ex is DbEntityValidationException)
			{
				return (ex as DbEntityValidationException).DbEntityValidationExceptionToString();
			}
			else if (ex is SocketException)
			{
				return $"Failed to establish connection: {ex.ExceptionToString()}";
			}

			return ex.ExceptionToString();
		}

		public static string ExceptionToString(this Exception ex)
		{
			StringBuilder sb = new StringBuilder(Environment.NewLine);

			sb.AppendLine($"Date/Time: {DateTime.Now.ToString()}");
			sb.AppendLine($"Exception Type: {ex.GetType().FullName}");
			sb.AppendLine($"Message: {ex.Message}");
			sb.AppendLine($"Source: {ex.Source}");

			// e.Data.Add("user", Thread.CurrentPrincipal.Identity.Name);
			foreach (var key in ex.Data.Keys)
			{
				sb.AppendLine($"{key.ToString()}: {ex.Data[key].ToString()}");
			}

			if (!ex.StackTrace.IsNullOrWhiteSpace())
			{
				sb.AppendLine($"Stack Trace: {ex.StackTrace}");
			}

			if (ex.InnerException != null)
			{
				sb.AppendLine($"Inner Exception: {ex.InnerException.ExceptionToString()}");
			}

			return sb.ToString();
		}

		/// <summary>
		/// A DbEntityValidationException extension method that formates validation errors to string.
		/// </summary>
		public static string DbEntityValidationExceptionToString(this DbEntityValidationException e)
		{
			var validationErrors = e.DbEntityValidationResultToString();
			var exceptionMessage = string.Format("{0}Validation errors:{1}{0}{2}", Environment.NewLine, validationErrors, e.ExceptionToString());
			return exceptionMessage;
		}

		/// <summary>
		/// A DbEntityValidationException extension method that aggregate database entity validation results to string.
		/// </summary>
		public static string DbEntityValidationResultToString(this DbEntityValidationException e)
		{
			return e.EntityValidationErrors
					.Select(dbEntityValidationResult => dbEntityValidationResult.DbValidationErrorsToString(dbEntityValidationResult.ValidationErrors))
					.Aggregate(string.Empty, (current, next) => string.Format("{0}{1}{2}", current, Environment.NewLine, next));
		}

		/// <summary>
		/// A DbEntityValidationResult extension method that to strings database validation errors.
		/// </summary>
		public static string DbValidationErrorsToString(this DbEntityValidationResult dbEntityValidationResult, IEnumerable<DbValidationError> dbValidationErrors)
		{
			var entityName = string.Format("[{0}]", dbEntityValidationResult.Entry.Entity.GetType().Name);
			const string indentation = "\t - ";
			var aggregatedValidationErrorMessages = dbValidationErrors.Select(error => string.Format("[{0} - {1}]", error.PropertyName, error.ErrorMessage))
												   .Aggregate(string.Empty, (current, validationErrorMessage) => current + (Environment.NewLine + indentation + validationErrorMessage));
			return string.Format("{0}{1}", entityName, aggregatedValidationErrorMessages);
		}
	}
}
