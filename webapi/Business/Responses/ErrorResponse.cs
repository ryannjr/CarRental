namespace webapi.Business.Responses {
    public class ErrorResponse {
        public string Error;

        public ErrorResponse(string error)
        {
            this.Error = error;
        }
    }
}
