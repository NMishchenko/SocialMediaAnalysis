namespace SocialMediaAnalysis.BLL.Enums;

public enum ErrorCode
{
    ApiKeyExhausted,
    ApiKeyMissing,
    ApiKeyInvalid,
    ApiKeyDisabled,
    ParametersMissing,
    ParametersIncompatible,
    ParameterInvalid,
    RateLimited,
    RequestTimeout,
    SourcesTooMany,
    SourceDoesNotExist,
    SourceUnavailableSortedBy,
    SourceTemporarilyUnavailable,
    UnexpectedError,
    UnknownError
}