using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace MySqlConnector.Utilities;

internal static class ActivitySourceHelper
{
	public const string DatabaseSystemTagName = "db.system";
	public const string StatusCodeTagName = "otel.status_code";

	public const string DatabaseSystemValue = "mysql";

	public const string ExecuteActivityName = "Execute";
	public const string OpenActivityName = "Open";

	public static readonly IEnumerable<KeyValuePair<string, object?>> DefaultTags = new KeyValuePair<string, object?>[]
	{
			new(DatabaseSystemTagName, DatabaseSystemValue),
	};

	public static void SetSuccess(this Activity? activity) => activity?.SetTag(StatusCodeTagName, "OK");

	public static void SetException(this Activity activity, Exception exception)
	{
		activity.SetTag(StatusCodeTagName, "ERROR");
		activity.SetTag("otel.status_description", exception is MySqlException mySqlException ? mySqlException.ErrorCode.ToString() : exception.Message);
		activity.SetTag("exception.type", exception.GetType().FullName);
		activity.SetTag("exception.message", exception.Message);
		activity.SetTag("exception.stacktrace", exception.StackTrace);
	}

	private static readonly AssemblyName AssemblyName = typeof(ActivitySourceHelper).Assembly.GetName();
	public static readonly ActivitySource ActivitySource = new("X-MySqlConnector-v1", AssemblyName.Version!.ToString());
}
