$ErrorActionPreference = "Stop"

function Register-User ($name, $email, $pass) {
    echo "Registering $email..."
    $body = @{
        nombre = $name
        apellido = "Test"
        email = $email
        password = $pass
    } | ConvertTo-Json
    curl.exe -X POST http://localhost:8080/api/auth/register -H "Content-Type: application/json" -d $body
}

function Login-User ($email, $pass) {
    echo "Logging in $email..."
    $body = @{
        email = $email
        password = $pass
    } | ConvertTo-Json
    $response = curl.exe -s -X POST http://localhost:8080/api/auth/login -H "Content-Type: application/json" -d $body
    $token = $response -replace '.*"token":"([^"]+)".*', '$1'
    return $token
}

# 1. Register Users
Register-User "Alice" "alice@test.com" "password"
Register-User "Bob" "bob@test.com" "password"

# 2. Login
$tokenA = Login-User "alice@test.com" "password"
$tokenB = Login-User "bob@test.com" "password"

echo "---------------------------------------------------"
echo "Testing Dashboard Isolation"
echo "---------------------------------------------------"

echo "User A (Alice) Dashboard:"
curl.exe -s -H "Authorization: Bearer $tokenA" http://localhost:8080/api/materias/dashboard
echo ""
echo "---------------------------------------------------"
echo "User B (Bob) Dashboard:"
curl.exe -s -H "Authorization: Bearer $tokenB" http://localhost:8080/api/materias/dashboard
echo ""
