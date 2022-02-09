using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingSolution.Data.Models;

[Table("incoming_request_http", Schema = "cp2_audit")]
public sealed record IncomingRequestHttp(
	[property: Key, Column("id")]
	long Id,
	[property: Column("tag"), MaxLength(256)]
	string? Tag,
	[property: Required, Column("http_method"), MaxLength(8)]
	string HttpMethod,
	[property: Required, Column("http_url"), MaxLength(2084)]
	string HttpUrl,
	[property: Required, Column("request_headers", TypeName = "jsonb")]
	string RequestHeaders,
	[property: Column("request_body", TypeName = "jsonb")]
	string? RequestBody,
	[property: Column("request_body_raw")]
	byte[]? RequestBodyRaw,
	[property: Required, Column("utc_created_at")]
	DateTime CreatedAt);