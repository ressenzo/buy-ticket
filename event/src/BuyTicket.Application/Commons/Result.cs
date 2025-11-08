using BuyTicket.Domain.Commons;

namespace BuyTicket.Application.Commons;

public class Result<T> where T : class
{
    private readonly List<Error> _errors;

    public T? Content { get; }

    public ResultType ResultType { get; }

    public bool IsSuccess => _errors.Count == 0;

    public IEnumerable<Error> Errors => _errors;

    private Result(
        T content,
        ResultType resultType,
        IEnumerable<Error> errors)
    {
        Content = content;
        ResultType = resultType;
        _errors = [];
        _errors.AddRange(errors);
    }

    public static Result<T> Success(T content) =>
        new(content, ResultType.SUCCESS, errors: []);

    public static Result<T> ValidationError(
        IEnumerable<Error> errors) =>
        new(content: null!, ResultType.VALIDATION_ERROR, errors);
}

public enum ResultType
{
    SUCCESS,
    VALIDATION_ERROR,
    INTERNAL_ERROR,
    NOT_FOUND
}
