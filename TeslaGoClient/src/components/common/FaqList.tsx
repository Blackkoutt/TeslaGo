import { Link } from "react-router-dom";
import Button, { ButtonStyle } from "./Button";
import { FAQ } from "../../models/response_models/FAQ";
import Accordion from "./Accordion";

interface FaqListProps {
  displayCount?: number;
}

export const FaqList = ({ displayCount }: FaqListProps) => {
  const faqs: FAQ[] = [
    {
      id: 1,
      question: "How can I rent a Tesla?",
      answer:
        "Choose your preferred model, rental period, and pickup/drop-off location from Palma Airport, Palma City Center, Alcudia, or Manacor.",
    },
    {
      id: 2,
      question: "What Tesla models are available for rent?",
      answer:
        "We offer the full range of Tesla passenger models, including the Model 3, Model S, Model X, and Model Y. Each car is fully electric and equipped with advanced features.",
    },
    {
      id: 3,
      question: "Can I pick up and return the car at different locations?",
      answer:
        "Yes! You can pick up and drop off your Tesla at any of our four locations across Mallorca: Palma Airport, Palma City Center, Alcudia, and Manacor.",
    },
    {
      id: 4,
      question: "What do I need to rent a Tesla?",
      answer:
        "To rent a Tesla, you need to be at least 18 years old and have a valid driver's license and a credit card.",
    },
    {
      id: 5,
      question: "How do I calculate the cost of my rental?",
      answer:
        "The rental price depends on the model, rental duration, and any additional options you choose (like insurance). You can easily calculate the total cost on our website by entering the rental dates and selecting your Tesla model.",
    },
    {
      id: 6,
      question: "Is insurance included with the rental?",
      answer:
        "Basic insurance coverage is included in the rental. However, you can opt for additional insurance coverage for more extensive protection during your rental.",
    },
  ];

  const displayedFaqs = displayCount !== undefined ? faqs.slice(0, displayCount) : faqs;

  return (
    <>
      <div className="flex flex-col px-48 gap-4">
        {displayedFaqs?.map((faq) =>
          faq ? <Accordion key={faq.id} header={faq.question} content={faq.answer} /> : null
        )}
      </div>
      {displayCount && (
        <div className="flex flex-col justify-center items-center gap-5">
          <div className="flex flex-col justify-center items-center">
            <p className="text-textPrimary">Didn't find the answer to your question?</p>
            <p className="text-textPrimary">Visit the full FAQ by clicking the button below.</p>
          </div>
          <Link to="/faq">
            <Button
              text="Learn More"
              width={170}
              height={53}
              fontSize={16}
              rounded={999}
              style={ButtonStyle.Primary}
              action={() => {}}
            />
          </Link>
        </div>
      )}
    </>
  );
};
