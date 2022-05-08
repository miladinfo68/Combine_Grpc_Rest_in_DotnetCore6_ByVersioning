// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: author.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcShared {
  public static partial class AuthorProtoService
  {
    static readonly string __ServiceName = "protos.author.AuthorProtoService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.GetAllAuthorsRequest> __Marshaller_protos_author_GetAllAuthorsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.GetAllAuthorsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.GetAllAuthorsResponse> __Marshaller_protos_author_GetAllAuthorsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.GetAllAuthorsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.GetAuthorRequest> __Marshaller_protos_author_GetAuthorRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.GetAuthorRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.GetAuthorResponse> __Marshaller_protos_author_GetAuthorResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.GetAuthorResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.AddAuthorRequest> __Marshaller_protos_author_AddAuthorRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.AddAuthorRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.AddAuthorResponse> __Marshaller_protos_author_AddAuthorResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.AddAuthorResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.EditAuthorRequest> __Marshaller_protos_author_EditAuthorRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.EditAuthorRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.EditAuthorResponse> __Marshaller_protos_author_EditAuthorResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.EditAuthorResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.DeleteAuthorRequest> __Marshaller_protos_author_DeleteAuthorRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.DeleteAuthorRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcShared.DeleteAuthorResponse> __Marshaller_protos_author_DeleteAuthorResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcShared.DeleteAuthorResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcShared.GetAllAuthorsRequest, global::GrpcShared.GetAllAuthorsResponse> __Method_GetAll = new grpc::Method<global::GrpcShared.GetAllAuthorsRequest, global::GrpcShared.GetAllAuthorsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_protos_author_GetAllAuthorsRequest,
        __Marshaller_protos_author_GetAllAuthorsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcShared.GetAuthorRequest, global::GrpcShared.GetAuthorResponse> __Method_GetById = new grpc::Method<global::GrpcShared.GetAuthorRequest, global::GrpcShared.GetAuthorResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_protos_author_GetAuthorRequest,
        __Marshaller_protos_author_GetAuthorResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcShared.AddAuthorRequest, global::GrpcShared.AddAuthorResponse> __Method_Add = new grpc::Method<global::GrpcShared.AddAuthorRequest, global::GrpcShared.AddAuthorResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_protos_author_AddAuthorRequest,
        __Marshaller_protos_author_AddAuthorResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcShared.EditAuthorRequest, global::GrpcShared.EditAuthorResponse> __Method_Update = new grpc::Method<global::GrpcShared.EditAuthorRequest, global::GrpcShared.EditAuthorResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_protos_author_EditAuthorRequest,
        __Marshaller_protos_author_EditAuthorResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcShared.DeleteAuthorRequest, global::GrpcShared.DeleteAuthorResponse> __Method_Delete = new grpc::Method<global::GrpcShared.DeleteAuthorRequest, global::GrpcShared.DeleteAuthorResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_protos_author_DeleteAuthorRequest,
        __Marshaller_protos_author_DeleteAuthorResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcShared.AuthorReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AuthorProtoService</summary>
    [grpc::BindServiceMethod(typeof(AuthorProtoService), "BindService")]
    public abstract partial class AuthorProtoServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcShared.GetAllAuthorsResponse> GetAll(global::GrpcShared.GetAllAuthorsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcShared.GetAuthorResponse> GetById(global::GrpcShared.GetAuthorRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcShared.AddAuthorResponse> Add(global::GrpcShared.AddAuthorRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcShared.EditAuthorResponse> Update(global::GrpcShared.EditAuthorRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcShared.DeleteAuthorResponse> Delete(global::GrpcShared.DeleteAuthorRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(AuthorProtoServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetById, serviceImpl.GetById)
          .AddMethod(__Method_Add, serviceImpl.Add)
          .AddMethod(__Method_Update, serviceImpl.Update)
          .AddMethod(__Method_Delete, serviceImpl.Delete).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AuthorProtoServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcShared.GetAllAuthorsRequest, global::GrpcShared.GetAllAuthorsResponse>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcShared.GetAuthorRequest, global::GrpcShared.GetAuthorResponse>(serviceImpl.GetById));
      serviceBinder.AddMethod(__Method_Add, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcShared.AddAuthorRequest, global::GrpcShared.AddAuthorResponse>(serviceImpl.Add));
      serviceBinder.AddMethod(__Method_Update, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcShared.EditAuthorRequest, global::GrpcShared.EditAuthorResponse>(serviceImpl.Update));
      serviceBinder.AddMethod(__Method_Delete, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcShared.DeleteAuthorRequest, global::GrpcShared.DeleteAuthorResponse>(serviceImpl.Delete));
    }

  }
}
#endregion