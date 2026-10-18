using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<Error> Errors { get; }
        protected Result(bool isSuccess, IReadOnlyList<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result Ok() => new Result(true, Array.Empty<Error>());
        public static Result Fail(Error error) => new Result(false, new[] { error });
        public static Result Fail(IReadOnlyList<Error> errors) => new Result(false, errors);
    }

    public class Result<T> : Result
    {
        public T Value { get; }
        public T Data => IsSuccess ? Value : default!;

        private Result(T value)
            : base(true, Array.Empty<Error>())
        {
            Value = value;
        }
        private Result(Error error)
            : base(false, new[] { error })
        {
            Value = default!;
        }
        private Result(IReadOnlyList<Error> errors)
            : base(false, errors)
        {
            Value = default!;
        }

        public static Result<T> Ok(T value) => new Result<T>(value);
        public static new Result<T> Fail(Error error) => new Result<T>(error);
        public static new Result<T> Fail(IReadOnlyList<Error> errors) => new Result<T>(errors);

        public static implicit operator Result<T>(T value) => Ok(value);
        public static implicit operator Result<T>(Error error) => Fail(error);
    }
}
