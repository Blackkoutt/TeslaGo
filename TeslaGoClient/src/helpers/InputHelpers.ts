import { FormEvent } from "react";

const ValidateNameOrSurname = (e: FormEvent<HTMLInputElement>) => {
  const input = e.target as HTMLInputElement;

  input.value = input.value.replace(/[^a-zA-Zà-ÿÀ-ßąćęłńóśźżĄĆĘŁŃÓŚŹŻ' -]/g, "");

  input.value = input.value.replace(/^[ '’-]+/, "");

  input.value = input.value.replace(/([ '’-])\1+/g, "$1");

  if (input.value && /^[a-zà-ÿÀ-ßąćęłńóśźżĄĆĘŁŃÓŚŹŻ' -]/i.test(input.value)) {
    input.value = input.value.charAt(0).toUpperCase() + input.value.slice(1);
  }
};

const CapitalizeFirstLetter = (e: FormEvent<HTMLInputElement>) => {
  const input = e.target as HTMLInputElement;
  if (input.value && /^[a-z]/i.test(input.value)) {
    input.value = input.value.charAt(0).toUpperCase() + input.value.slice(1);
  }
};

const PhoneNumberOnInput = (e: FormEvent<HTMLInputElement>) => {
  const input = e.target as HTMLInputElement;
  input.value = input.value.replace(/[^0-9\s\+\-\(\)]/g, "");
};

const ValidateEmail = (e: FormEvent<HTMLInputElement>) => {
  const input = e.target as HTMLInputElement;

  // remove all not allowed chars
  input.value = input.value.replace(/[^a-zA-Z0-9à-ÿÀ-ßąćęłńóśźżĄĆĘŁŃÓŚŹŻ._@-]/g, "");

  // remove " " "." "'" "-" from start
  input.value = input.value.replace(/^[ .'-]+/, "");

  // remove repetition of values ( '..', '--', '@@')
  input.value = input.value.replace(/([. '-@])\1+/g, "$1");

  // only one @
  const atCount = (input.value.match(/@/g) || []).length;
  if (atCount > 1) input.value = input.value.replace(/@([^@]*)$/, "");
};

const InputHelper = {
  ValidateNameOrSurname,
  CapitalizeFirstLetter,
  PhoneNumberOnInput,
  ValidateEmail,
};

export default InputHelper;
