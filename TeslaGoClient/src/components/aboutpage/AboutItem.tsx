interface AboutItemProps {
  header: string;
  content: string;
  imageLeft?: boolean;
  image: string;
  imageAlt: string;
}

export const AboutItem = ({ header, content, image, imageAlt, imageLeft = false }: AboutItemProps) => {
  return (
    <div className="flex flex-row justify-between items-center">
      {imageLeft && <img src={image} className="object-contain max-w-[40%] max-h-[350px]" alt={imageAlt} />}
      <article className="max-w-[55%] -translate-y-6 flex flex-col gap-2">
        <h3 className="font-bold text-[26px]">{header}</h3>
        <p className="text-textPrimary text-justify">{content}</p>
      </article>
      {!imageLeft && <img src={image} className="object-contain max-w-[40%] max-h-[350px]" alt={imageAlt} />}
    </div>
  );
};
