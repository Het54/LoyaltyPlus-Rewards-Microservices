FROM grafana/k6:latest
COPY ["LoadTesting/test.js", "/scripts/test.js"]
ENTRYPOINT ["k6", "run", "/scripts/test.js"]
