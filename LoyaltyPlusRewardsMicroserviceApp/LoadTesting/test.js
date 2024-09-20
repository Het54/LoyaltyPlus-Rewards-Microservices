import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 100,          // virtual users
    duration: '120s',  // duration
};

export default function () {
    let res = http.get('http://customer-registration-and-auth-service/api/Customer');
    check(res, {
        'status is 200': (r) => r.status === 200,
    });
    sleep(1);
}
