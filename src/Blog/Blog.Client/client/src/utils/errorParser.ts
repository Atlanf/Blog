import { AxiosError } from "axios";

/* Add sending errors to the server */ 
export default function parseAxiosError(
    error: AxiosError,
    method: string,
    address: string
) {
    if (error.response) {
        console.log("Error: request was made and response was recieved.");
    }
    else if (error.request) {
        console.log("Error: request was made but no response was recieved.")
    }
    else {
        console.log("Error: ", error.message);
    }
}