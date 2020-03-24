using System;

namespace Expensely.Domain
{
    /// <summary>
    /// Represents a result of some operation, with status information and an error message.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class with the specified parameters.
        /// </summary>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error message.</param>
        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && !string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException("A success result can not contain an error message.");
            }

            if (!isSuccess && string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException("A failure result must contain an error message.");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        /// <summary>
        /// Gets a value indicating whether the result is a success result.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating whether the result is a failure result.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Gets the error string.
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Returns a success <see cref="Result"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="Result"/> with the success flag set.</returns>
        public static Result Ok() => new Result(true, string.Empty);

        /// <summary>
        /// Returns a success <see cref="Result"/> with the specified value.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="value">The result value.</param>
        /// <returns>A new instance of <see cref="Result"/> with the success flag set.</returns>
        public static Result<TValue> Ok<TValue>(TValue? value)
            where TValue : class
            => new Result<TValue>(value, true, string.Empty);

        /// <summary>
        /// Returns a fail <see cref="Result"/> with the specified error message.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <returns>A new instance of <see cref="Result"/> with the specified error message and failure flag set.</returns>
        public static Result Fail(string error) => new Result(false, error);

        /// <summary>
        /// Returns a fail <see cref="Result{T}"/> with the specified error message.
        /// </summary>
        /// <typeparam name="TValue">The result type.</typeparam>
        /// <param name="error">The error message.</param>
        /// <returns>A new instance of <see cref="Result{T}"/> with the specified error message and failure flag set.</returns>
        public static Result<TValue> Fail<TValue>(string error)
            where TValue : class
            => new Result<TValue>(null, false, error);
    }

    /// <summary>
    /// Represents a result of some operation, with status information and an error message.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    public class Result<TValue> : Result
        where TValue : class
    {
        private readonly TValue? _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TValueType}"/> class with the specified parameters.
        /// </summary>
        /// <param name="value">The result value.</param>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error message.</param>
        protected internal Result(TValue? value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        /// <summary>
        /// Returns the result value if the result is successful, otherwise throws an exception.
        /// </summary>
        /// <returns>The result value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure"/> is true.</exception>
        public TValue? Value()
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("Can not access the value of a failure result.");
            }

            return _value;
        }
    }
}
