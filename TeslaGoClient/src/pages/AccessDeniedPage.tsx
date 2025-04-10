import unauthorized from "../assets/unauthorized.png";

export const AccessDeniedPage = () => {
  return (
    <div className="flex flex-row justify-center items-center gap-14 py-16 max-w-[1250px]">
      <img src={unauthorized} alt="Access denied photo" className="object-contain w-[420px] h-[420px]" />
      <article className="max-w-[600px]">
        <h1 className="text-[#2F2F2F] text-[42px]">401: Unauthorized</h1>
        <div>
          <p className="text-[16px] mt-6">
            An error occurred during access authorization. For security reasons, access to the resource has
            been blocked.
          </p>
          <p className="text-[16px] mt-2">
            We apologize for the inconvenience. If you're unsure why this happened and it occurred
            unexpectedly, our support team is here to help. Feel free to contact us at{" "}
            <a href="mailto:support@teslago.com" className="text-blue-500 hover:underline">
              support@teslago.com
            </a>
            .
          </p>
        </div>
      </article>
    </div>
  );
};
