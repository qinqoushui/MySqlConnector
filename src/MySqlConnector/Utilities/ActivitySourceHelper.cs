using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace MySqlConnector.Utilities;

internal static class ActivitySourceHelper
{
	public const string DatabaseConnectionStringTagName = "db.connection_string";
	public const string DatabaseNameTagName = "db.name";
	public const string DatabaseSystemTagName = "db.system";
	public const string DatabaseUserTagName = "db.user";
	public const string NetPeerNameTagName = "net.peer.name";
	public const string NetTransportTagName = "net.transport";
	public const string StatusCodeTagName = "otel.status_code";
	public const string ThreadIdTagName = "thread.id";

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

	public static readonly ActivitySource ActivitySource = CreateActivitySource();

	private static ActivitySource CreateActivitySource()
	{
		var assembly = typeof(ActivitySourceHelper).Assembly;
		var version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()!.Version;
		return new("X-MySqlConnector-v1", version);
	}
}
