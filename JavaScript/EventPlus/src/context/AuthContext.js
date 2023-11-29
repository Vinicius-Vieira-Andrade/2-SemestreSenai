import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

export const userContext = createContext(null);

export const userDecodeToken = (theToken) => {
  const decoded = jwtDecode(theToken); //aqui retorna payload

  return {
    role: decoded.role,
    name: decoded.name,
    userId: decoded.jti,
    token: theToken,
  };
};
