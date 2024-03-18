# Influx .NET samples
Ukázky práce s InfluxDB pomocí .NET

## Docker
Konfigurace kontejneru InfluxDB je v docker-compose.yml.
Pro spuštění docker-compose je potřeba přejmenovat soubor **main.env.dist** na **main.env** a nastavit v něm proměnné.

Ověření dosutpnosti pomocí healthcheck: http://localhost:8068/health

### Konfigurace
Základní konfigurace je pomocí ENV proměnných v souboru **main.env**.
Zde je také nastavení admin přístupu.

### CLI
Pomocí CLI je možné se přihlásit do kontejneru a pracovat s InfluxDB.
V kontejneru pak otevřít clienta:
```bash
influx -username <uzivatelske_jmeno> -password '<heslo>'
```
Založení nové databáze:
```bash
CREATE DATABASE <nazev_databaze>
``` 
#### Přístupy
Pro řešení přístupů do DB je vhodné založit účty pro čtení a pro zápis odděleně.

Zde je příklad pro založení obou takových účtů:
```bash
CREATE USER worker_writer WITH PASSWORD 'password'
CREATE USER worker_reader WITH PASSWORD 'password'

GRANT WRITE ON worker TO worker_writer
GRANT READ ON worker TO worker_reader
``` 

## API
Pomocí HTTP API je možné pracovat s InfluxDB.
V souboru **HttpTests/samples.http** jsou příklady dotazů na API.
