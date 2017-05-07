package com.mastercoder.rutas_mcturistic.view.InicioSesion;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.facebook.AccessToken;
import com.facebook.CallbackManager;
import com.facebook.FacebookCallback;
import com.facebook.FacebookException;
import com.facebook.login.LoginResult;
import com.facebook.login.widget.LoginButton;
import com.google.android.gms.auth.api.Auth;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.auth.api.signin.GoogleSignInResult;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.SignInButton;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthCredential;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FacebookAuthProvider;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.auth.GoogleAuthProvider;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.MainActivity;

public class Login extends FragmentActivity implements GoogleApiClient.OnConnectionFailedListener {

    static final int SING_IN_CODE = 777; // Variable estática para la validación de la cuenta Google
    CallbackManager callbackManager;
    LoginButton loginButton;
    FirebaseAuth firebaseAuth; // Variable que recibe la instancia de la sesión
    FirebaseAuth.AuthStateListener firebaseStateListener; // Variable que detecta el estado de la sesión
    SignInButton btnGoogle;
    GoogleApiClient GAC; // Variable que sirve para conectar al Cliente Web de Google
    ProgressBar pgbLoading;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_container);
        callbackManager = CallbackManager.Factory.create();
        loginButton = (LoginButton) findViewById(R.id.login_button);
        loginButton.registerCallback(callbackManager, new FacebookCallback<LoginResult>(){
            @Override
            public void onSuccess(LoginResult loginResult) {
                // App code
                handleFacebookAccessToken(loginResult.getAccessToken());
            }

            @Override
            public void onCancel() {
                // App code
            }

            @Override
            public void onError(FacebookException exception) {
                // App code
            }
        });

        // Se generan los valores para las variables que requiere Google para las sesiones
        generarVariables();

        btnGoogle = (SignInButton) findViewById(R.id.btnGoogle);
        btnGoogle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Se realiza un Intent para conectar al API de inicio de sesión de Google y se recibe un resultado
                Intent intent = Auth.GoogleSignInApi.getSignInIntent(GAC);
                startActivityForResult(intent,SING_IN_CODE);
            }
        });

        // Se obtiene la instancia de la sesión que está iniciada
        firebaseAuth = FirebaseAuth.getInstance();
        firebaseStateListener = new FirebaseAuth.AuthStateListener() {
            @Override
            public void onAuthStateChanged(@NonNull FirebaseAuth firebaseAuth) {
                // Se obtiene el usuario de la sesión
                FirebaseUser user = firebaseAuth.getCurrentUser();
                // Si existe algún usuario en la sesión, se redirecciona al menú principal
                if (user != null) {
                    goMain();
                }
            }
        };

        pgbLoading = (ProgressBar) findViewById(R.id.pgbLoading);

    }

    private void generarVariables() {
        // Se definen las opciones para el tipo de inicio de sesión
        GoogleSignInOptions GSIO = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
                // Se solicita el Token nediante la conexión al ID del servicio de la web
                .requestIdToken(getString(R.string.WebID))
                .requestEmail() // Se solicita el Email de la cuenta
                .build();

        // Se genera la conexión al Cliente de la API
        GAC = new GoogleApiClient.Builder(Login.this)
                .enableAutoManage(this, this)
                .addApi(Auth.GOOGLE_SIGN_IN_API, GSIO)
                .build();
    }

    // TODO Métodos de inicio de sesión de Facebook
    private void handleFacebookAccessToken(AccessToken accessToken) {
        pgbLoading.setVisibility(View.VISIBLE);
        btnGoogle.setVisibility(View.GONE);
        loginButton.setVisibility(View.GONE);
        // Se crea la credencial de inicio de sesión de Facebook con el Token del acceso
        AuthCredential credential = FacebookAuthProvider.getCredential(accessToken.getToken());
        // Se inicia la sesión con la credencial obtenida
        firebaseAuth.signInWithCredential(credential).addOnCompleteListener(this, new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                pgbLoading.setVisibility(View.GONE);
                btnGoogle.setVisibility(View.VISIBLE);
                loginButton.setVisibility(View.VISIBLE);
                if(!task.isSuccessful()){
                    Toast.makeText(getApplicationContext(), "Error al iniciar sesión", Toast.LENGTH_LONG ).show();
                }
            }
        });
    }

    // TODO Métodos predeterminados de la clase
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // Si el resultado de la actividad de Google es igual al código de inicio de sesión
        if (requestCode == SING_IN_CODE){
            // Se genera el resultado del inicio de sesión por medio del usuario que lo solicita
            GoogleSignInResult result = Auth.GoogleSignInApi.getSignInResultFromIntent(data);
            if (result.isSuccess()) {
                // Google Sign In was successful, authenticate with Firebase
                GoogleSignInAccount account = result.getSignInAccount();
                firebaseAuthGoogle(account);
            }
        } else {
            // Si no es sesión de Google, este hace referencia a la sesión de Facebook
            callbackManager.onActivityResult(requestCode, resultCode, data);
        }
    }

    @Override
    protected void onStart(){
        super.onStart();
        // Agrega a la variable de la sesión el estado de la sesión actual
        firebaseAuth.addAuthStateListener(firebaseStateListener);
    }

    @Override
    protected void onStop(){
        super.onStop();
        // si el estado de la sesión es nulo
        if (firebaseStateListener != null) {
            // Quita los estados a la variable de la sesión
            firebaseAuth.removeAuthStateListener(firebaseStateListener);
        }
    }

    // Método que redirige a la actividad principal de la aplicación
    private void goMain(){
        Intent intent = new Intent(this, MainActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
    }


    // TODO Métodos de inicio de sesión de Google
    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {

    }

    // Método que recibe el resultado del inicio de sesión
    private void handleGoogleSignIn(GoogleSignInResult result) {
        // Si es exitosa, se registra el inicio de sesión
        if (result.isSuccess()){
            firebaseAuthGoogle(result.getSignInAccount());
        } else {
            Toast.makeText(this, "No se puede iniciar sesión. Intente más tarde", Toast.LENGTH_LONG).show();
        }
    }

    // Método que sirve para el registro del inicio de sesión
    private void firebaseAuthGoogle(GoogleSignInAccount account){
        pgbLoading.setVisibility(View.VISIBLE);
        btnGoogle.setVisibility(View.GONE);
        loginButton.setVisibility(View.GONE);
        // Se crea una credencial de Google por medio del Token de la sesión
        AuthCredential credential = GoogleAuthProvider.getCredential(account.getIdToken(), null);
        // Se hace el inicio de sesión por medio de la credencial
        firebaseAuth.signInWithCredential(credential).addOnCompleteListener(this, new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                pgbLoading.setVisibility(View.GONE);
                btnGoogle.setVisibility(View.VISIBLE);
                loginButton.setVisibility(View.VISIBLE);
                if (!task.isSuccessful()){
                    Toast.makeText(getApplicationContext(), "No se puede autentificar la sesión. Intente más tarde", Toast.LENGTH_LONG).show();
                }
            }
        });
    }
}
