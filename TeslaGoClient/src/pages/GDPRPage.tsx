export const GDPRPage = () => {
  return (
    <div className="w-full py-10">
      <article className="flex flex-col gap-6">
        <h1>GDPR (General Data Protection Regulation)</h1>
        <div className="flex flex-col gap-6">
          <p>
            TeslaGo takes the privacy of its users seriously. Below, you will find information about the
            processing of personal data in accordance with the General Data Protection Regulation (GDPR) of
            the European Parliament and Council (EU) 2016/679 of April 27, 2016.
          </p>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Data Controller</h2>
            <p>
              The controller of your personal data is TeslaGo, located at{" "}
              <strong>Plaça d'Espanya 1, 07002 Palma, Mallorca</strong>, email:{" "}
              <strong>teslago@gmail.com</strong>, phone: <strong>123 456 789</strong>.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Purposes and Legal Grounds for Data Processing</h2>
            <p>Your personal data may be processed for the following purposes:</p>
            <ol className="list-decimal ml-10">
              <li className="mt-1">
                Service provision – to provide services through the TeslaGo platform (Art. 6(1)(b) GDPR).
              </li>
              <li className="mt-1">Customer service – if you contact us (Art. 6(1)(f) GDPR).</li>
              <li className="mt-1">
                Legal obligations – in accordance with applicable law (Art. 6(1)(c) GDPR).
              </li>
            </ol>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Data Retention Period</h2>
            <p>
              Personal data will be retained for as long as necessary to fulfill the purposes of processing or
              until consent is withdrawn if the processing is based on consent.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>User Rights</h2>
            <p>As a user, you have the right to:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">Access your data,</li>
              <li className="mt-1">Rectify your data,</li>
              <li className="mt-1">Delete your data,</li>
              <li className="mt-1">Restrict processing,</li>
              <li className="mt-1">Object to the processing of your data,</li>
              <li className="mt-1">Withdraw your consent to the processing of personal data.</li>
            </ul>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Sharing of Personal Data</h2>
            <p>
              Your data may be shared with third parties who assist us in providing services, such as IT
              service providers, provided that appropriate data protection measures are in place.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Data Protection Measures</h2>
            <p>
              TeslaGo applies appropriate technical and organizational measures to ensure the security of
              personal data and protect it from unauthorized access.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Contact and Complaints</h2>
            <p>
              If you have any questions regarding the processing of your data or wish to report a data
              protection breach, please contact us at <strong>teslago@gmail.com</strong>. You may also lodge a
              complaint with the Spanish Data Protection Agency (AEPD).
            </p>
          </section>
        </div>
      </article>
    </div>
  );
};
