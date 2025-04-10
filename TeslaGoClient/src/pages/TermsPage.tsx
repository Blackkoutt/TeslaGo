export const TermsPage = () => {
  return (
    <div className="w-full py-10">
      <div className="flex flex-col gap-6">
        <h1>Terms and Conditions</h1>
        <div className="flex flex-col gap-6">
          <p>
            These terms and conditions define the rules for using the TeslaGo platform. By using the service,
            the user agrees to the terms outlined in this document and commits to complying with its rules.
          </p>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Definitions</h2>
            <p>In these terms and conditions, the following terms are used:</p>
            <ul className="list-disc ml-10">
              <li className="mt-1">
                <strong>Administrator</strong> – the entity managing the TeslaGo service, responsible for its
                operation and development,
              </li>
              <li className="mt-1">
                <strong>User</strong> - a natural or legal person using the functionalities of the service,
              </li>
              <li className="mt-1">
                <strong>Service</strong> – the TeslaGo platform, which enables the booking and management of
                car rentals,
              </li>
              <li className="mt-1">
                <strong>Content</strong> – all materials, information, and data published by users within the
                service,
              </li>
            </ul>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Conditions of Use</h2>
            <p>
              Each user is required to use the service in accordance with the law, good customs, and social
              norms. It is prohibited to engage in activities that may disrupt the service's operation,
              including any form of hacking, attempting to gain unauthorized access to other users' accounts,
              or any actions that compromise the platform's security. Users must publish content in compliance
              with the terms and conditions and adhere to the publication rules.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Registration and User Account</h2>
            <p>
              To gain full access to the service's functionality, users may be required to register. This
              process requires providing accurate personal information, including an email address and a
              unique username. Users are responsible for protecting their login credentials and must not share
              them with third parties. In the case of suspected unauthorized access to an account, the user
              should immediately contact the service administrator.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Liability</h2>
            <p>
              The service administrator makes every effort to ensure the proper operation of the service.
              However, they are not responsible for any interruptions to the service caused by technical
              issues, failures, or factors beyond their control. Users use the service at their own risk, and
              the administrator is not liable for any damages arising from improper use of the service or
              actions by third parties.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Content Publishing Rules</h2>
            <p>
              Users have the right to publish content within the service. However, they are obligated to
              comply with applicable laws and the platform's rules. Published materials must not contain
              illegal, offensive, vulgar, violent, hateful, or third-party rights-violating content. In case
              of violation of these rules, the administrator reserves the right to remove the content, and in
              extreme cases, to block the user's account.
            </p>
          </section>
          <section className="flex flex-col gap-2">
            <h2 style={{ fontSize: 26 }}>Changes to the Terms and Conditions</h2>
            <p>
              The administrator reserves the right to change the terms and conditions at any time. Any changes
              will take effect once published on the platform. Users will be notified of significant changes
              through the service or via email. Continued use of the service after changes are made indicates
              acceptance of the updated terms.
            </p>
          </section>
        </div>
      </div>
    </div>
  );
};
