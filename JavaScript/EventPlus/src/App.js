import "./App.css";
import Rotas from "./routes";
import { userContext } from "./context/AuthContext";
import { useState } from "react";

function App() {
    const [userData, setUserData] = useState({});
  return (
    <userContext.Provider value={{ userData, setUserData }}>
      <Rotas />;
    </userContext.Provider>
  );
}

export default App;
