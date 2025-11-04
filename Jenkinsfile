pipeline {
    agent any

    environment {
        PATH = "/usr/local/share/dotnet:${PATH}"
    }

    stages {
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

        stage('Run Tests') {
            steps {
                sh 'dotnet test'
            }
        }
    }
}
