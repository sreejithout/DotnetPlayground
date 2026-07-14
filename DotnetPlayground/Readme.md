# Dotnet Playground
## .NET 10 api solution to learn the fundamentals step by step
01. [Based on .NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
02. Layering (Trying a Clean Architecture here)
    - Business Logic Layer **DotnetPlayground.BLL**
        - Interfaces (even the one's for Repositories)
        - Models
        - DTOs
        - Enums
    - Data Access Layer **DotnetPlayground.DAL**
    - as per dependency inversion or clean architecture level, we are going to move the interfaces for the the repositories to BLL layer. Means, we will be referencing BLL from DAL and not other way around.
03. Dependency Injection
    - [built-in DI provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-10.0)
04. [Configurations](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-10.0)
    - [Options Pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-10.0)
    - [IOptionsSnapshot](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1?view=dotnet-plat-ext-7.0)
    - [IOptionsMonitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1?view=dotnet-plat-ext-7.0)
05. [Routing](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-10.0)
06. [Model Binding](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-10.0)
07. Http Client 
    - [IHttpClientFactory](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0)
08. [CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-10.0)
09. [EF Core](https://docs.microsoft.com/en-us/ef/core/)
10. [Enforcing HTTPs](https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-10.0)      
  - [Security Headers (HSTS)](https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-10.0#hsts)
11. [Rate Limiting](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-10.0)
12. [API Versioning](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/api-versioning?view=aspnetcore-10.0)
13. [Open API Documentation with Scalar instead of Swagger](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/openapi?view=aspnetcore-10.0)
14. [Structured Logging with Serilog](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-10.0#structured-logging)
15. [Health Checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0)
16. [Cancellation Token](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads?view=net-8.0)
17. [Hybrid Caching](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/?view=aspnetcore-10.0)
18. [Idempotency](https://docs.microsoft.com/en-us/aspnet/core/web-api/idempotency?view=aspnetcore-10.0) 

## Things todo in pipeline
- [OpenTelemetry, Distributed Tracking](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/distributed-tracing?view=dotnet-10)
- [Standardized API Response](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/standardized-api-response?view=aspnetcore-10.0)
- [Standardized Error Response](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/standardized-error-response?view=aspnetcore-10.0)
- DTOs
- [Resiliency (Retry, Circuit Breaker, Fallback, Timeout)](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency)
  - [Retry](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implementing-retry)
  - [Circuit Breaker](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency)
  - [Fallback](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency#fallback)
  - [Timeout](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency#timeout)
- [Polly for Retry, Circuit Breaker and more](https://github.com/App-vNext/Polly)
      - Resilient(https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0#resilient-http-requests)
- 
- Azure Logic Apps for workflow orchestration. [https://learn.microsoft.com/en-us/azure/logic-apps/](https://learn.microsoft.com/en-us/azure/logic-apps/)
- Package Registry
  - [https://docs.microsoft.com/en-us/nuget/hosting-packages/overview](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview)

 ## CI/CD
 - [CI/CD Pipeline with Azure DevOps](https://learn.microsoft.com/en-us/azure/devops/pipelines/?view=azure-devops)
  - [Azure DevOps Pipeline for .NET 10](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops)
  - [Azure DevOps Pipeline for .NET 10 with Docker](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker)
  - [Azure DevOps Pipeline for .NET 10 with Docker and Kubernetes](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-and-kubernetes)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes and Helm](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-and-helm)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm and ArgoCD](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-and-argocd)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD and FluxCD](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-and-fluxcd)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD and GitHub Actions](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-and-github-actions)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions and Jenkins](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-and-jenkins)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins and Terraform](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-and-terraform)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform and Ansible](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-and-ansible)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible and Spinnaker](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-and-spinnaker)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker and Argo Workflows](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-and-argo-workflows)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker, Argo Workflows and Tekton](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-argo-workflows-and-tekton)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker, Argo Workflows, Tekton and GitLab CI/CD](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-argo-workflows-tekton-and-gitlab-ci-cd)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker, Argo Workflows, Tekton, GitLab CI/CD and CircleCI](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-argo-workflows-tekton-gitlab-ci-cd-and-circleci)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker, Argo Workflows, Tekton, GitLab CI/CD, CircleCI and Bamboo](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-argo-workflows-tekton-gitlab-ci-cd-circleci-and-bamboo)
  - [Azure DevOps Pipeline for .NET 10 with Docker, Kubernetes, Helm, ArgoCD, FluxCD, GitHub Actions, Jenkins, Terraform, Ansible, Spinnaker, Argo Workflows, Tekton, GitLab CI/CD, CircleCI, Bamboo and TeamCity](https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#docker-kubernetes-helm-argocd-fluxcd-github-actions-jenkins-terraform-ansible-spinnaker-argo-workflows-tekton-gitlab-ci-cd-circleci-bamboo-and-teamcity)