namespace App.Common.Http
{
    using System.Collections.Generic;
    using App.Common.Validation;

    public interface IResponseData<DataType>
    {
        void SetStatus(System.Net.HttpStatusCode httpStatusCode);
        void SetErrors(IList<ValidationError> errors);
        void SetData(DataType data);
    }
}