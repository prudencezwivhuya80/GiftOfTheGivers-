import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
    http.get('https://localhost:7297/');
    http.get('https://localhost:7297/Home/Donate');
    http.get('https://localhost:7297/Home/Volunteer');
    sleep(1);
}