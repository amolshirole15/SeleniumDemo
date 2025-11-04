pipeline {
    agent any

    environment {
        "PATH+DOTNET" = "/usr/local/share/dotnet"
    }

    stages {
        stage('Check Tools') {
            steps {
                sh 'echo $PATH'
                sh 'which sh'
                sh 'which dotnet'
                sh 'dotnet --info'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
    }

    // post {
    //     always {
    //         junit 'TestResults/*.trx'
    //     }
    // }
}
