namespace GeometryLibrary.Helpers;

public class GeometryResult<TModel>
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }
    public TModel? Value { get; }
    
    private GeometryResult(bool isSuccess, string errorMessage, TModel? value)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Value = value;
    }
    
    public static GeometryResult<TModel> Success(TModel value)
    {
        return new GeometryResult<TModel>(true, string.Empty, value);
    }

    public static GeometryResult<TModel> Failure(string errorMessage)
    {
        return new GeometryResult<TModel>(false, errorMessage, default);
    }
}