using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Utilities;

public class OperationResult
{
    public string Message { get; set; }
    public OperationResultStatus Status { get; set; }

    public static OperationResult Error()
    {
        return new OperationResult()
        {
            Message = "خطا",
            Status = OperationResultStatus.Error
        };
    }
    public static OperationResult Error(string mess)
    {
        return new OperationResult()
        {
            Message = mess,
            Status = OperationResultStatus.Error
        };
    }
    public static OperationResult NotFound()
    {
        return new OperationResult()
        {
            Message = "صفحه یافت نشد",
            Status = OperationResultStatus.NotFound
        };
    }
    public static OperationResult NotFound(string mess)
    {
        return new OperationResult()
        {
            Message = mess,
            Status = OperationResultStatus.NotFound
        };
    }
    public static OperationResult Success()
    {
        return new OperationResult()
        {
            Message = "عملیات موفقیت آمیز بود",
            Status = OperationResultStatus.Success
        };
    }
    public static OperationResult Success(string mess)
    {
        return new OperationResult()
        {
            Message = mess,
            Status = OperationResultStatus.Success
        };
    }


    public enum OperationResultStatus
    {
        Error=10,
        Success=200,
        NotFound=404
    }
}
