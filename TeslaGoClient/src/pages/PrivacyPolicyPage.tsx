export const PrivacyPolicyPage = () => {
  return (
    <div className="w-full py-10">
      <div className="flex flex-col gap-6">
        <h1>Privacy Policy</h1>
        <div className="flex flex-col gap-6">
          <p>
            TeslaGo values the privacy of its users and ensures transparency in the processing of personal
            data. This privacy policy outlines the types of data collected, how it is used, and the rights
            users have in relation to their personal information.
          </p>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Types of Data Collected</h2>
            <p>When using the TeslaGo service, the following data may be collected:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">Email address,</li>
              <li className="mt-1">Full name,</li>
              <li className="mt-1">Driving license nr</li>
            </ul>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>How Data is Collected</h2>
            <p>Personal data may be collected through:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">Registration and contact forms,</li>
              <li className="mt-1">Cookies and other tracking technologies</li>
            </ul>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Purpose of Data Processing</h2>
            <p>Personal data may be processed for the following purposes:</p>
            <ol className="list-decimal ml-10">
              <li className="mt-1">Providing services through the TeslaGo website,</li>
              <li className="mt-1">Contacting users for technical or organizational matters,</li>
              <li className="mt-1">Customizing content and advertisements according to user preferences,</li>
              <li className="mt-1">Conducting analysis and statistics on website traffic.</li>
            </ol>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Cookies</h2>
            <p>TeslaGo uses cookies for the following purposes:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">Maintaining user sessions</li>
            </ul>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Data Security</h2>
            <p>
              TeslaGo applies appropriate technical and organizational measures to protect the personal data
              of users from unauthorized access and processing.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>User Rights</h2>
            <p>Users have the right to:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">Access their data,</li>
              <li className="mt-1">Correct or delete their data,</li>
              <li className="mt-1">Restrict data processing</li>
            </ul>
            <p>
              To exercise these rights, users can contact us at <strong>teslago@gmail.com</strong>.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Changes to the Privacy Policy</h2>
            <p>
              TeslaGo reserves the right to make changes to this privacy policy. Users will be notified of any
              significant changes on the website.
            </p>
          </section>
        </div>
      </div>
    </div>
  );
};
