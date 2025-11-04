pipeline {
    agent any

    environment {
        // PATH = "${env.PATH}:/usr/local/share/dotnet"
        "PATH+DOTNET" = "/usr/local/share/dotnet"
    }

    options {
        shell('/bin/bash')   // explicitly tell Jenkins to use bash
    }

    stages {
        stage('Check Tools') {
            steps {
                sh '''
                    echo "Current PATH: $PATH"
                    which dotnet || echo "dotnet not found"
                    dotnet --info
                '''
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
