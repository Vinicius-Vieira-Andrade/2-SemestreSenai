import axios from "axios";


// const apiPort = "7118";
// const localApi = `https://localhost:${apiPort}/api`;
const externalAPi = 'https://eventovini.azurewebsites.net/api';

const api = axios.create({baseURL : externalAPi});

export default api