import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    stages: [
        { duration: '20s', target: 10 },
        { duration: '20s', target: 30 },
        { duration: '20s', target: 60 },
        { duration: '20s', target: 100 },
        { duration: '10s', target: 0 },
    ],
};

export default function () {
    http.get('https://localhost:7297/');
    http.get('https://localhost:7297/Home/Donate');
    http.get('https://localhost:7297/Home/Volunteer');
    sleep(1);
}