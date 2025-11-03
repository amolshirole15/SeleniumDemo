pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
            }
        }
    }

    post {
        always {
            junit '**/test_results.trx'
        }
    }
}
