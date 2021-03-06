﻿using System;

using System.Collections.Generic;

using System.Linq;
using Android.Content;
using Com.Bumptech.Glide;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace NomadCode.BotFramework.Droid
{
	public static class MessageCellExtensions
	{
		public static void SetMessageCell (this List<BotMessage> messages, MessageCell cell, int row)
		{
			if (messages?.Count > 0 && messages.Count > row)
			{
				var message = messages [row];

				//var cell = holder.ItemView as MessageCell;

				cell.Key = row;

				if (message.Head)
				{
					cell.SetHeader (row, message);
				}

				if (message.HasText)
				{
					cell.SetMessage (message.AttributedText);
				}

				if (message.HasAtachments)
				{
					foreach (var attachment in message.Attachments)
					{
						// images
						if (attachment.Content.HasImages)
						{
							foreach (var image in attachment.Content.Images)
							{
								cell.AddHeroImage (row, image.Url);
							}
						}

						// title
						if (attachment.Content.HasTitle)
						{
							cell.AddAttachmentTitle (attachment.Content.AttributedTitle);
						}

						// subtitle
						if (attachment.Content.HasSubtitle)
						{
							cell.AddAttachmentSubtitle (attachment.Content.AttributedSubtitle);
						}

						// text
						if (attachment.Content.HasText)
						{
							cell.AddAttachmentText (attachment.Content.AttributedText);
						}

						// buttons
						if (attachment.Content.HasButtons)
						{
							cell.SetButtons (attachment.Content.Buttons.Select (b => (b.Title, b.Value.ToString ())).ToArray ());
						}
					}
				}

				// Cells must inherit the table view's transform
				// This is very important, since the main table view may be inverted
				//cell.Transform = tableView.Transform;

				//return cell;
			}

			//return null;
		}


		static void AddHeroImage (this MessageCell cell, int row, string imageUrl)
		{
			var index = cell.AddHeroImage ();

			//cell.HeroImageViews [index].SetCacheFormat (getCacheFormat (MessageCell.HeroScaledImageSize));

			if (string.IsNullOrEmpty (imageUrl))
			{
				cell.SetHeroImage (row, index, null);
			}
			else
			{
				var placeholder = getPlaceholderImage (MessageCell.HeroScaledImageSize);

				Glide.With (cell.Context).Load (imageUrl).Placeholder (placeholder).Into (cell.HeroImageViews [index]);

				//using (NSUrl url = new NSUrl (imageUrl))
				//{
				//	cell?.HeroImageViews [index].SetImage (url, placeholder, (img) => cell.SetHeroImage (indexPath.Row, index, img), (err) =>
				//	{
				//		cell.SetHeroImage (indexPath.Row, index, null);

				//		Log.Debug (err.LocalizedDescription);
				//	});
				//}
			}
		}


		static void SetThumbnailImage (this MessageCell cell, int row, string imageUrl)
		{
			//cell.ThumbnailImageView.SetCacheFormat (getCacheFormat (MessageCell.ThumbnailImageSize));

			cell.AddThumbnailImage ();

			if (string.IsNullOrEmpty (imageUrl))
			{
				cell.SetThumbnailImage (row, null);
			}
			else
			{
				var placeholder = getPlaceholderImage (MessageCell.ThumbnailImageSize);

				Glide.With (cell.Context).Load (imageUrl).Placeholder (placeholder).Into (cell.ThumbnailImageView);

				//using (NSUrl url = new NSUrl (imageUrl))
				//{
				//	cell?.ThumbnailImageView.SetImage (url, placeholder, (img) => cell.SetThumbnailImage (indexPath.Row, img), (err) =>
				//	{
				//		cell.SetThumbnailImage (indexPath.Row, null);

				//		Log.Debug (err.LocalizedDescription);
				//	});
				//}
			}
		}


		static void SetHeader (this MessageCell cell, int row, BotMessage message)
		{
			cell.SetHeader (message.LocalTimeStamp, message.Activity?.From?.Name);

			//cell.ImageView.SetCacheFormat (getCacheFormat (MessageCell.AvatarImageSize));

			//if (message.Activity.From.Id == "DigitalAgencies")
			//{
			//	cell.SetAvatar (row, UIImage.FromBundle ("avatar_microsoft"));
			//}
			//else
			//{
			var avatarUrl = string.IsNullOrEmpty (message.Activity?.From?.Id) ? string.Empty : BotClient.Shared.GetAvatarUrl (message.Activity.From.Id);

			if (string.IsNullOrEmpty (avatarUrl))
			{
				cell.SetAvatar (row, null);
			}
			else
			{
				var placeholder = getPlaceholderImage (MessageCell.AvatarImageSize);

				Glide.With (cell.Context).Load (avatarUrl).Placeholder (placeholder).Into (cell.AvatarView);

				//using (NSUrl url = new NSUrl (avatarUrl))
				//{
				//	cell?.ImageView.SetImage (url, placeholder, (img) => cell.SetAvatar (indexPath.Row, img), (err) =>
				//	{
				//		cell.SetAvatar (indexPath.Row, null);

				//		Log.Debug (err.LocalizedDescription);
				//	});
				//}
			}
			//}
		}


		static Dictionary<Size, Drawable> placeholders = new Dictionary<Size, Drawable> ();

		static Drawable getPlaceholderImage (Size size)
		{
			if (!placeholders.TryGetValue (size, out Drawable placeholder))
			{
				placeholder = new BitmapDrawable (Bitmap.CreateBitmap (size.Width, size.Height, Bitmap.Config.Argb8888));

				placeholders [size] = placeholder;
			}

			return placeholder;
		}


		//static HNKCacheFormat getCacheFormat (CGSize size)
		//{
		//	var name = $"avatar{size.GetHashCode ()}";

		//	var format = HNKCache.SharedCache.Formats [name] as HNKCacheFormat;

		//	if (format == null)
		//	{
		//		format = new HNKCacheFormat (name)
		//		{
		//			Size = new CGSize (size.Width, size.Height),
		//			ScaleMode = HNKScaleMode.AspectFit,
		//			DiskCapacity = 10 * 1024 * 1024, // 10MB
		//			PreloadPolicy = HNKPreloadPolicy.LastSession
		//		};
		//	}

		//	return format;
		//}


		//public static MessageCell GetAutoCompleteCell (this List<ISearchResults> items, UITableView tableView, NSIndexPath indexPath)
		//{
		//	if (items?.Count > 0 && items.Count > indexPath.Row)
		//	{
		//		//Log.Debug ($"GetAutoCompleteCell = [{indexPath}]");

		//		var cell = tableView.DequeueReusableCell (MessageCellReuseIds.AutoCompleteReuseId, indexPath) as MessageCell;
		//		cell.IndexPath = indexPath;

		//		var text = items [indexPath.Row].Name;

		//		//if (FoundPrefix.Equals (hashStr))
		//		//{
		//		//  text = $"# {text}";
		//		//}
		//		//else if (FoundPrefix.Equals (colonStr) || FoundPrefix.Equals (plusColonStr))
		//		//{
		//		//  text = $":{text}:";
		//		//}

		//		cell.TitleLabel.Text = text;
		//		cell.SelectionStyle = UITableViewCellSelectionStyle.Default;

		//		return cell;
		//	}

		//	return null;
		//}


		public static float GetMessageHeight (this List<BotMessage> messages, int row)
		{
			//Log.Debug ($"table: {tableView.Frame.Width - 49}, contentWidth: {MessageCell.ContentWidth}");

			if (messages?.Count > 0 && messages.Count > row)
			{
				var message = messages [row];

				float height = message.CellHeight;

				if (height > 0)
				{
					return height;
				}

				message.Head = messages.IsHead (row);

				//var bodyBounds = message.HasText ? message.AttributedText.GetBoundingRect (new CGSize (MessageCell.ContentWidth, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, null) : CGRect.Empty;

				//height = bodyBounds.Height;// + MessageCell.StackViewPadding;// + 8.5f; // empty stackView = 3.5f + bottom padding = 5

				//Log.Debug($"{width}");

				if (message.Head) height += 36.5f; // pading(10) + title(21.5) + padding(5) + content(height)


				if (message.HasAtachments)
				{
					foreach (var attachment in message.Attachments)
					{
						// images
						if (attachment.Content.HasImages)
						{
							foreach (var image in attachment.Content.Images)
							{
								height += MessageCell.HeroImageSize.Height;// + MessageCell.StackViewPadding;
							}
						}

						// title
						//if (attachment.Content.HasTitle)
						//{
						//	var attachmentTitleBounds = attachment.Content.AttributedTitle.GetBoundingRect (new CGSize (MessageCell.ContentWidth, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, null);
						//	height += attachmentTitleBounds.Height + MessageCell.StackViewPadding;
						//}

						//// subtitle
						//if (attachment.Content.HasSubtitle)
						//{
						//	var attachmentSubtitleBounds = attachment.Content.AttributedSubtitle.GetBoundingRect (new CGSize (MessageCell.ContentWidth, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, null);
						//	height += attachmentSubtitleBounds.Height + MessageCell.StackViewPadding;
						//}

						//// text
						//if (attachment.Content.HasText)
						//{
						//	var attachmentTextBounds = attachment.Content.AttributedText.GetBoundingRect (new CGSize (MessageCell.ContentWidth, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, null);
						//	height += attachmentTextBounds.Height + MessageCell.StackViewPadding;
						//}

						// buttons
						if (attachment.Content.HasButtons)
						{
							height += (32 * attachment.Content.Buttons.Count);
							height += 4 * (attachment.Content.Buttons.Count - 1);
							//height += MessageCell.StackViewPadding;
						}
					}
				}

				message.CellHeight = height;

				return height;
			}

			return 0;
		}
	}
}
