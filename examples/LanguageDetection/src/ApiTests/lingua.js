import http from "k6/http";
import { check } from "k6";

const text = "Hello, world!";

export default function () {
  const response = http.post(
    "http://127.0.0.1:5000/api/v1/detect-language",
    JSON.stringify({ text }),
    {
      headers: {
        "Content-Type": "application/json",
      },
    }
  );

  check(response.json(), {
    "correct detection": (r) => r.detectedLanguage === "English",
  });
}

export const options = {
  scenarios: {
    constant: {
      executor: "constant-arrival-rate",
      rate: 100,
      duration: "10s",
      preAllocatedVUs: 500,
    },
  },
};
